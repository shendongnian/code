    void me_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
    {
       var memo = (sender as MemoEdit);
       var maxChars = memo.Properties.MaxLength;
       lblContactWithCharCount.Text = memo.Text.Length + "/" + maxChars;
    }
