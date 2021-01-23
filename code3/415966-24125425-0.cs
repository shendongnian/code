    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json.Serialization;
    
       namespace Newtonsoft.Json.Tests.TestObjects
       {
        public class IdReferenceResolver : IReferenceResolver
        {
            private readonly IDictionary<Guid, PersonReference> _people = new Dictionary<Guid, PersonReference>();
    
            public object ResolveReference(object context, string reference)
            {
                Guid id = new Guid(reference);
    
                PersonReference p;
                _people.TryGetValue(id, out p);
    
                return p;
            }
    
            public string GetReference(object context, object value)
            {
                PersonReference p = (PersonReference)value;
                _people[p.Id] = p;
    
                return p.Id.ToString();
            }
    
            public bool IsReferenced(object context, object value)
            {
                PersonReference p = (PersonReference)value;
    
                return _people.ContainsKey(p.Id);
            }
    
            public void AddReference(object context, string reference, object value)
            {
                Guid id = new Guid(reference);
    
                _people[id] = (PersonReference)value;
            }
        }
    }
