    namespace WebApplication1
    {
        using System;
        using System.Collections.Generic;
        using System.Web.UI.WebControls;
        public partial class _Default : System.Web.UI.Page
        {
            private const string UploadViewState = "UploadViewState";
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    // initialise list and store in ViewState
                    ViewState[UploadViewState] = new List<string>();
                }
            }
            protected void btnAdd_Click(object sender, EventArgs e)
            {
                // Get the list from ViewState and add the new item
                var _filesToUpload = (List<string>)ViewState[UploadViewState];
                _filesToUpload.Add(text1.Text);
                // Now recreate the row adding cells for each file...
                foreach (string item in _filesToUpload)
                {
                    TableCell cell = new TableCell();
                    ImageButton button = new ImageButton();
                    button.ImageUrl = "~/images/kill.png";
                    button.Attributes.Add("onclick", "removeAttachment");
                    Label label = new Label();
                    label.Text = item;
                    cell.Controls.Add(button);
                    cell.Controls.Add(label);
                    attachedFilesRow.Cells.Add(cell);
                }
            }
        }
    }
