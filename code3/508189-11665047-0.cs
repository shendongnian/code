    public class Wrapper
    {
        public TypeEnum Type { get; set; }
        public string Name { get; set; }
        // other common props
        public string CustomProperty1 { get; set; }
        public object ConvertToRealObject()
        {
            switch(this.Type)
            {
                case TypeEnum.Audio:
                    return new Audio { Name = this.Name, Album = this.CustomProperty1 }
                /* other type handling */
            }
        }
    }
