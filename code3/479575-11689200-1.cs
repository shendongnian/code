    using System;
    using System.Collections.Specialized;
    using System.Web.UI;
    
    public partial class DynamicData_FieldTemplates_CKEditor_EditField : System.Web.DynamicData.FieldTemplateUserControl
    {
    
        //refer http://www.graytechnology.com/Blog/post/Using-a-Rich-Text-Editor-with-Dynamic-Data.aspx for explanation
    
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    
        protected override void ExtractValues(IOrderedDictionary dictionary)
        {
            dictionary[Column.Name] = ConvertEditedValue(TextBox1.Text);
    
        }
    
        public override Control DataControl
        {
            get
            {
    
                return TextBox1;
            }
    
        } 
    
    }
