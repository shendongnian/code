    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class _Default : Page
    {
        private static readonly List<String> _listOfThings = new List<String> { "John", "Mary", "Joe" };
        private List<TextBox> _myDynamicTextBoxes;
    
    
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            _myDynamicTextBoxes = new List<TextBox>();
            var i = 0;
            foreach (var item in _listOfThings)
            {
                var tbox = new TextBox {ID = "TextBox" + (i++),Text=item};
                placeHolder1.Controls.Add(tbox); //make sure you are adding to the appropriate container (which must live in a Form with runat="server")
                _myDynamicTextBoxes.Add(tbox);
            }
        }
    
        protected void Button1_Click(Object sender, EventArgs e)
        {
            foreach (var tbox in _myDynamicTextBoxes)
            {
                Response.Write(String.Format("You entered '{0}' in {1}<br/>", tbox.Text, tbox.ID));
            }
        }
    }
 
