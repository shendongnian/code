    protected void Page_Load(object sender, EventArgs e) {
         if (!IsPostBack) {
              MyHtmlEditor.ContextMenuItems.CreateDefaultItems();
              MyHtmlEditor.ContextMenuItems.Insert(0, new HtmlEditorContextMenuItem("Add Title...", "AddTitle"));
              MyHtmlEditor.ContextMenuItems.Insert(1, new HtmlEditorContextMenuItem("Change Title...", "ChangeTitle"));
              MyHtmlEditor.ContextMenuItems.Insert(2, new HtmlEditorContextMenuItem("Remove Title", "RemoveTitle"));
         }
    }
