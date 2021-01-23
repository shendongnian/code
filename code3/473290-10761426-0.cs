    public interface IDescribable
    {
        int ID { get; set; }
        string Description { get; set; }
    }
    public class ClassA
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int ColorID 
        { 
            get { return ID; } 
            set { ID = value; } 
        }
        public string ColorDescription 
        { 
            get { return Description; } 
            set { Description = value; } 
        }
    }
    public class ClassB
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int TypeID 
        { 
            get { return ID; } 
            set { ID = value; } 
        }
        public string TypeDescription 
        { 
            get { return Description; } 
            set { Description = value; } 
        }
    }
    public void ExFunctionSave(IDescribable d, int id, string desc)    
    {
        d.ID = id;
        d.Description = desc;
        Save();
    }
