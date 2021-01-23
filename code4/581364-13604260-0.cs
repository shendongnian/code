    namespace BinaryProxy
    {
        using System;
        using System.Collections.Generic;
        using System.IO;
    
        using System.Runtime.Serialization;
        using System.Runtime.Serialization.Formatters.Binary;
    
        [Serializable]
        class TestClass
        {
           
    
            public bool mvalue;
    
            public TestClass(bool value)
            {
                BoolValue = value;
            }
    
            public bool BoolValue
            {
                get
                {
                    // won't happen
                    SideEffect = DateTime.Now.ToString();
                    return mvalue;
                }
                
                set
                {
                    mvalue = value;
                }
            }
    
            public string SideEffect { get; set; }
    
        }
    
        class ProxyTestClass
        {
            private Dictionary<string, object> data = new Dictionary<string, object>();
    
            public Object GetData(string name)
            {
                if(data.ContainsKey(name))
                {
                    return data[name];
                }
                return null;
            }
            public void SetData(string name, object value)
            {
                data[name] = value;
            }
    
            public IEnumerable<KeyValuePair<string, object>> Dump()
            {
                return data;
            }
        }
    
        class SurrogateTestClassConstructor : ISerializationSurrogate
        {
            private ProxyTestClass mProxy;
            /// <summary>
            /// Populates the provided <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with the data needed to serialize the object.
            /// </summary>
            /// <param name="obj">The object to serialize. </param>
            /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> to populate with data. </param>
            /// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext"/>) for this serialization. </param>
            /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
            public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
            {
                throw new NotImplementedException();
            }
    
            /// <summary>
            /// Populates the object using the information in the <see cref="T:System.Runtime.Serialization.SerializationInfo"/>.
            /// </summary>
            /// <returns>
            /// The populated deserialized object.
            /// </returns>
            /// <param name="obj">The object to populate. </param>
            /// <param name="info">The information to populate the object. </param>
            /// <param name="context">The source from which the object is deserialized. </param>
            /// <param name="selector">The surrogate selector where the search for a compatible surrogate begins. </param>
            /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
            public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
            {
                if (mProxy == null) mProxy = new ProxyTestClass();
                var en = info.GetEnumerator();
                while (en.MoveNext())
                {
                    mProxy.SetData(en.Current.Name, en.Current.Value);
    
    
                }
                return mProxy;
    
            }
    
            
    
        }
    
        sealed class DeserializeBinder : SerializationBinder
        {
            public override Type BindToType(string assemblyName, string typeName)
            {
    
    
                return typeof(ProxyTestClass);
            }
        }
    
        static class Program
        {
    
            static void Main()
            {
                var tc = new TestClass(true);
                byte[] serialized;
                using (var fs = new MemoryStream())
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(fs, tc);
                    serialized = fs.ToArray();
    
                    var surrSel = new SurrogateSelector();
                    surrSel.AddSurrogate(typeof(ProxyTestClass),
                        new StreamingContext(StreamingContextStates.All), new SurrogateTestClassConstructor());
    
                    using (var fs2 = new MemoryStream(serialized))
                    {
                        var formatter2 = new BinaryFormatter();
                        formatter2.Binder = new DeserializeBinder();
                        formatter2.SurrogateSelector = surrSel;
                        var deser = formatter2.Deserialize(fs2) as ProxyTestClass;
                        foreach (var c in deser.Dump())
                        {
                            Console.WriteLine("{0} = {1}", c.Key, c.Value);
                        }
                    }
    
                }
    
            }
        }
    }
