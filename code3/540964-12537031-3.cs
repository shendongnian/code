    [DataContract()]
    public class Transaction
    {
        public Transaction()
        {
            this.Id = Guid.Empty;
        }
    
        /// <summary>
        /// Gets or sets the unique identifier for this transaction.
        /// </summary>
        /// <value>
        /// A <see cref="Guid"/> that represents the unique identifier for this transaction.
        /// </value>
        [DataMember()]
        public Guid Id
        {
            get;
            set;
        }
    
        /// <summary>
        /// Gets or sets a value indicating if this transaction has been completed.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if this transaction has been completed; otherwise, <see langword="false"/>.
        /// </value>
        [DataMember()]
        public bool IsComplete
        {
            get;
            set;
        }
    
        /// <summary>
        /// Gets or sets the action being performed.
        /// </summary>
        /// <value>The action being performed.</value>
        [DataMember()]
        public string Action
        {
            get;
            set;
        }
    
        /// <summary>
        /// Gets or sets the serialized representation of the entity participating in the transaction.
        /// </summary>
        /// <value>The serialized representation of the entity participating in the transaction.</value>
        [DataMember()]
        public string Entity
        {
            get;
            set;
        }
    
        /// <summary>
        /// Gets or sets the assembly qualified name of the entity participating in the transaction.
        /// </summary>
        /// <value>
        /// The <see cref="Type.AssemblyQualifiedName"/> of the <see cref="Entity"/>.
        /// </value>
        [DataMember()]
        public string EntityType
        {
            get;
            set;
        }
    
        /// <summary>
        /// Returns the <see cref="Entity"/> as a type of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to project the <see cref="Entity"/> as.</typeparam>
        /// <returns>
        /// An object of type <typeparamref name="T"/> that represents the <see cref="Entity"/>.
        /// </returns>
        public T As<T>() where T : class
        {
            T result    = default(T);
    
            var serializer = new XmlSerializer(typeof(T));
    
            using (var reader = XmlReader.Create(new MemoryStream(Encoding.UTF8.GetBytes(this.Entity))))
            {
                result  = serializer.Deserialize(reader) as T;
            }
    
            return result;
        }
    
        /// <summary>
        /// Serializes the specified <paramref name="entity"/>.
        /// </summary>
        /// <typeparam name="T">The type of entity being serialized.</typeparam>
        /// <param name="entity">The entity to serialize.</param>
        public static Transaction From<T>(T entity, string action = null) where T : class
        {
            var transaction = new Transaction();
    
            transaction.EntityType  = typeof(T).AssemblyQualifiedName;
            transaction.Action      = action;
    
            var serializer  = new XmlSerializer(typeof(T));
            byte[] data     = null;
    
            using (var stream = new MemoryStream())
            {
                serializer.Serialize(stream, entity);
                stream.Flush();
    
                data        = stream.ToArray();
            }
    
            transaction.Entity = Encoding.UTF8.GetString(data);
    
            return transaction;
        }
    }
    
    [DataContract()]
    public class Foo
    {
        public Foo()
        {
    
        }
    
        [DataMember()]
        public string PropertyA
        {
            get;
            set;
        }
    
        [DataMember()]
        public int PropertyB
        {
            get;
            set;
        }
    
        [DataMember()]
        public Foo PropertyC
        {
            get;
            set;
        }
    }
