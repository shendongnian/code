    string jsonString = 
        JsonConvert.SerializeObject(new MarkInfo(), Formatting.Indented);
    return jsonString;
    public class MarkInfo
    {  
        private List<string> finalMarks;
        private List<string> evalMarks;
        public List<string> FinalMarks
        { 
           get { return this.finalMarks ?? (this.finalMarks = new List<string>()); }
           set { this.finalMarks = value; }        
        }
        
        public List<string> EvalMarks
        { 
           get { return this.evalMarks ?? (this.evalMarks = new List<string>()); }
           set { this.evalMarks = value; }        
        }
    }
