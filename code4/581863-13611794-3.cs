	class FilePathEditor : UITypeEditor
	{
		public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return System.Drawing.Design.UITypeEditorEditStyle.Modal;
		}
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			FilePath path = (FilePath)value;
			OpenFileDialog openFile = new OpenFileDialog();
			openFile.FileName = path.Path;
			if (openFile.ShowDialog() == DialogResult.OK)
				path.Path = openFile.FileName;
			return path;
		}
	}
