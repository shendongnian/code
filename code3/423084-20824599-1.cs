	private void UpdateTextBox( Exception exception = null ) {
		textBox1.Text = string.Empty;
		if ( exception != null ) {
			textBox1.Text = exception.Message;
			return;
		}
		if ( !File.Exists( FileName ) ) {
			textBox1.Text = string.Format( "File '{0}' does not exist.", FileName );
			return;
		}
		var lines = File.ReadLines( FileName );
		textBox1.Text = string.Join( Environment.NewLine, lines );
	}
