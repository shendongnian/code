    using System;
    using System.Collections.Specialized;
    using System.Web.UI;
    
    namespace MyProject.DynamicData
    {
    	public partial class MultilineText_EditField : System.Web.DynamicData.FieldTemplateUserControl
    	{
    		protected void Page_Load(object sender, EventArgs e)
    		{
    			Editor.MaxLength = Column.MaxLength;
    			Editor.ToolTip = Column.Description;
    
    			SetUpValidator(RequiredFieldValidator1);
    			SetUpValidator(RegularExpressionValidator1);
    			SetUpValidator(DynamicValidator1);
    		}
    
    		public override void DataBind()
    		{
    			Editor.Text = FieldValueEditString;
    
    			base.DataBind();
    		}
    
    		protected override void OnPreRender(EventArgs e)
    		{
    			Page.ClientScript.RegisterOnSubmitStatement(
    				this.GetType(),
    				string.Format("kfckpb_{0}", this.ClientID),
    				string.Format("$('#{0}').val($('#{1}').val());", State.ClientID, Editor.ClientID)
    				);
    
    			base.OnPreRender(e);
    		}
    
    
    		protected override void ExtractValues(IOrderedDictionary dictionary)
    		{
    			dictionary[Column.Name] = ConvertEditedValue(State.Value);
    		}
    
    		public override Control DataControl
    		{
    			get
    			{
    				return Editor;
    			}
    		}
    
    	}
    }
