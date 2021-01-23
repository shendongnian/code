    [DataContract]
    public class FormulaStructure
    {
        [DataMember]
        public AFormulaItemStructure FormulaItem;
    }
    [DataContract]
    [KnownType(typeof(ColumnStructure))]
    [KnownType(typeof(FunctionStructure))]
    [KnownType(typeof(OperandStructure))]
    public abstract class AFormulaItemStructure { }
    [DataContract(Name="column")]
    public class ColumnStructure : AFormulaItemStructure
    {
        [DataMember(Name="type")]
        public string Type;
        [DataMember(Name = "field")]
        public string Field;
        [DataMember(Name = "display")]
        public string Display;
    }
    
    [DataContract(Name="function")]
    public class FunctionStructure : AFormulaItemStructure
    {
        [DataMember(Name = "type")]
        public string Type;
        [DataMember(Name = "name")]
        public string Name;
        [DataMember(Name = "parameters")]
        public string Parameters;
    }
    
    [DataContract(Name = "operand")]
    public class OperandStructure : AFormulaItemStructure
    {
        [DataMember(Name = "type")]
        public string Type;
        [DataMember(Name = "left")]
        public string Left;
        [DataMember(Name = "right")]
        public string Right;
    }
