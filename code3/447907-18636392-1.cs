    private void SaveMetadata(Document Doc) {
      Doc.BuiltInDocumentProperties["Title"].Value = this.Title.Text;
      Doc.BuiltInDocumentProperties["Subject"].Value = this.Subject.Text;
      Doc.BuiltInDocumentProperties["Category"].Value = this.Category.Text;
      Doc.BuiltInDocumentProperties["Keywords"].Value = this.Keywords.Text;
      Doc.BuiltInDocumentProperties["Author"].Value = this.Author.Text;
      Doc.BuiltInDocumentProperties["Comments"].Value = this.Comments.Text;
    }
