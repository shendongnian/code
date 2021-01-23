        InitializeComponent();
        testChk.SizeChanged += testChk_SizeChanged;
        txtForCheckBox.Text = "Some text, test, test, test.";
        txtForCheckBox.TextTrimming = TextTrimming.WordEllipsis;
        txtForCheckBox.TextWrapping = TextWrapping.NoWrap;
    }
    void testChk_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        txtForCheckBox.MaxWidth = testChk.ActualWidth;
        txtWidth.Text = testChk.ActualWidth.ToString();
    }
