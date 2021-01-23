    partial class Parameter 
    {
        public Parameter(AnAbstract inputObject)
        {
            this.Name = inputObject.Name;
            this.Description = inputObject.Description;
            this.IsNumeric = inputObject.IsNumeric;
            if (this.IsNumeric) 
            {
               this.Min = (inputObject as ANumericAbstract).Min;
               this.Max = (inputObject as ANumericAbstract).Max; 
            }
            else 
            {
              foreach(Object val in (inputObject as ANonNumericAbstract).Values)
              {
                this.Values.Add(val);
              }
            }
        }
    }
       
