    public Form1()
    {
        InitializeComponent();
        ICSharpCode.AvalonEdit.TextEditor textEditor = new ICSharpCode.AvalonEdit.TextEditor();
        textEditor.ShowLineNumbers = true;
        textEditor.FontFamily = new System.Windows.Media.FontFamily("Consolas");
        textEditor.FontSize = 12.75f;
    
        string dir = @"C:\Temp\";
        #if DEBUG
        dir = @"C:\Dev\Sandbox\SharpDevelop-master\src\Libraries\AvalonEdit\ICSharpCode.AvalonEdit\Highlighting\Resources\";
        #endif
    
        if (File.Exists(dir + "CSharp-Mode.xshd"))
        {
          Stream xshd_stream = File.OpenRead(dir + "CSharp-Mode.xshd");
          XmlTextReader xshd_reader = new XmlTextReader(xshd_stream);    
          // Apply the new syntax highlighting definition.
          textEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.Xshd.HighlightingLoader.Load(xshd_reader, ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance);
          xshd_reader.Close();
          xshd_stream.Close();
        }
        //Host the WPF AvalonEdiot control in a Winform ElementHost control
        ElementHost host = new ElementHost();
        host.Dock = DockStyle.Fill;
        host.Child = textEditor;
        this.Controls.Add(host);
    }
