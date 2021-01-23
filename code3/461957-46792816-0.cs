    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    
    namespace customserialization
    {
        /// <summary>
        /// IValueProvider personalizado  para manejar max depth level
        /// </summary>
        public class CustomDynamicValueProvider : DynamicValueProvider, IValueProvider
        {
            MemberInfo _memberInfo;
            MaxDepthHandler _levelHandler;
    
            public CustomDynamicValueProvider(MemberInfo memberInfo, MaxDepthHandler levelHandler) : base(memberInfo)
            {
                _memberInfo = memberInfo;
                _levelHandler = levelHandler;
            }
    
            public new object GetValue(object target)
            {
                //Si el valor a serializar es un objeto se incrementa el nivel de profundidad. En el caso de las listas el nivel se incrementa en el evento OnSerializing
                if (((PropertyInfo)_memberInfo).PropertyType.IsClass) this._levelHandler.IncrementLevel();
    
                var rv = base.GetValue(target);
    
                //Al finalizar la obtención del valor se decrementa. En el caso de las listas el nivel se decrementa en el evento OnSerialized
                if (((PropertyInfo)_memberInfo).PropertyType.IsClass) this._levelHandler.DecrementLevel();
    
                return rv;
            }
        }
    
        /// <summary>
        /// Maneja los niveles de serialización
        /// </summary>
        public class MaxDepthHandler
        {
            int _maxDepth;
            int _currentDepthLevel;
    
            /// <summary>
            /// Nivel actual
            /// </summary>
            public int CurrentDepthLevel { get { return _currentDepthLevel; } }
    
            public MaxDepthHandler(int maxDepth)
            {
                this._currentDepthLevel = 1;
                this._maxDepth = maxDepth;
            }
    
            /// <summary>
            /// Incrementa el nivel actual
            /// </summary>
            public void IncrementLevel()
            {
                this._currentDepthLevel++;
            }
    
            /// <summary>
            /// Decrementa el nivel actual
            /// </summary>
            public void DecrementLevel()
            {
                this._currentDepthLevel--;
            }
    
            /// <summary>
            /// Determina si se alcanzó el nivel actual
            /// </summary>
            /// <returns></returns>
            public bool IsMaxDepthLevel()
            {
                return !(this._currentDepthLevel < this._maxDepth);
            }
        }
    
        public class ShouldSerializeContractResolver : DefaultContractResolver
        {
    
            MaxDepthHandler _levelHandler;
    
            public ShouldSerializeContractResolver(int maxDepth)
            {
                this._levelHandler = new MaxDepthHandler(maxDepth);
            }
            
    
            void OnSerializing(object o, System.Runtime.Serialization.StreamingContext context)
            {
                //Antes de serializar una lista se incrementa el nivel. En el caso de los objetos el nivel se incrementa en el método GetValue del IValueProvider
                if (o.GetType().IsGenericList())
                    _levelHandler.IncrementLevel();
            }
    
            void OnSerialized(object o, System.Runtime.Serialization.StreamingContext context)
            {
                //Despues de serializar una lista se decrementa el nivel. En el caso de los objetos el nivel se decrementa en el método GetValue del IValueProvider
                if (o.GetType().IsGenericList())
                    _levelHandler.DecrementLevel();
            }
    
            protected override JsonContract CreateContract(Type objectType)
            {
                var contract = base.CreateContract(objectType);
                contract.OnSerializingCallbacks.Add(new SerializationCallback(OnSerializing));
                contract.OnSerializedCallbacks.Add(new SerializationCallback(OnSerialized));
    
                return contract;
            }
    
    
            protected override IValueProvider CreateMemberValueProvider(MemberInfo member)
            {
                var rv = base.CreateMemberValueProvider(member);
    
                if (rv is DynamicValueProvider) //DynamicValueProvider es el valueProvider usado en general
                {
                    //Utilizo mi propio ValueProvider, que utilizar el levelHandler
                    rv = new CustomDynamicValueProvider(member, this._levelHandler);
                }
    
                return rv;
            }
    
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                JsonProperty property = base.CreateProperty(member, memberSerialization);
    
                var isObjectOrList = ((PropertyInfo)member).PropertyType.IsGenericList() || ((PropertyInfo)member).PropertyType.IsClass;
    
               
    
                property.ShouldSerialize =
                        instance =>
                        {
                            var shouldSerialize = true;
                            //Si se alcanzo el nivel maximo y la propiedad (member) actual a serializar es un objeto o lista no se serializa (shouldSerialize = false)
                            if (_levelHandler.IsMaxDepthLevel() && isObjectOrList)
                                shouldSerialize = false;                        
    
                            return shouldSerialize;
                        };
    
                return property;
            }
    
    
    
        }
    
        public static class Util
        {
            public static bool IsGenericList(this Type type)
            {
                foreach (Type @interface in type.GetInterfaces())
                {
                    if (@interface.IsGenericType)
                    {
                        if (@interface.GetGenericTypeDefinition() == typeof(ICollection<>))
                        {
                            // if needed, you can also return the type used as generic argument
                            return true;
                        }
                    }
                }
                return false;
            }
        }
    }
