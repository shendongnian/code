	private void LocationChoose_Click(object sender, RoutedEventArgs e)
	{
		FolderBrowserDialog folderDlg = new FolderBrowserDialog();
		folderDlg.ShowDialog();
		//ViewModel.FolderName = folderDlg.SelectedPath;
		textBox1.Text = folderDlg.SelectedPath;
		BindingExpression exp = this.textBox1.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty);
		exp.UpdateSource();
	}
