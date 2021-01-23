     public partial class TblValues
     {
         private XElement fldXmlValues = null;
         public XElement FieldXmlValues
         {   
            get{
               if (fldXmlValues == null){
                  fldXmlValues = XElement.Parse(this.FieldValues);
                  fldXmlValues.Changed += (s,e) => this.FieldValues = fldXmlValues.ToString();
               }
               return fldXmlValues;
            }
            set{
               fldXmlValues = value;
               fldXmlValues.Changed += (s,e) => this.FieldValues = fldXmlValues.ToString();
               this.FieldValues = fldXmlValues.ToString();
            }
         }
      }
