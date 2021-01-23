        //using Word = Microsoft.Office.Interop.Word;
        //using Office = Microsoft.Office.Core;
        Word.Application application;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            application = this.Application;
            application.WindowBeforeRightClick +=
                new Word.ApplicationEvents4_WindowBeforeRightClickEventHandler(application_WindowBeforeRightClick);
            application.CustomizationContext = application.ActiveDocument;
            Office.CommandBar commandBar = application.CommandBars["Text"];
            Office.CommandBarButton button = (Office.CommandBarButton)commandBar.Controls.Add(
                Office.MsoControlType.msoControlButton);
            button.accName = "My Custom Button";
            button.Caption = "My Custom Button";
        }
        public void application_WindowBeforeRightClick(Word.Selection selection, ref bool Cancel)
        {
            if (selection != null && !String.IsNullOrEmpty(selection.Text))
            {
                string selectionText = selection.Text;
                if (selectionText.Contains("C#"))
                    SetCommandVisibility("My Custom Button", false);
                else
                    SetCommandVisibility("My Custom Button", true);
            }
        }
        private void SetCommandVisibility(string name, bool visible)
        {
            application.CustomizationContext = application.ActiveDocument;
            Office.CommandBar commandBar = application.CommandBars["Text"];
            commandBar.Controls[name].Visible = visible;
        }
