        public class CustomClassList : IList<CustomClass>
        {
            public void Add (CustomClass item)
            {
                if(this.Select(t => t.Name).Contains(item.Name))
                    // Do whatever here...
                else
                    // Do whatever else here...
            }
        
            // ... other IList implementations here ...
        }
