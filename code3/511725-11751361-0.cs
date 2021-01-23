     public partial class TblValues
     {
         private XElement fldXmlValues = null;
         public XElement FieldXmlValues
         {   
            get{
               if (fldXmlValues == null){
                  fldXmlValues = XElement.Parse(this.FieldValues);
                  fldXmlValues.Changed += (s,e) => this.FieldsValues = fldXmlValues.ToString();
               }
               return fldXmlValues;
            }
            set{
               fldXmlValues = value;
               fldXmlValues.Changed += (s,e) => this.FieldsValues = fldXmlValues.ToString();
               this.FieldsValues = fldXmlValues.ToString();
            }
         }
      }
