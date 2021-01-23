    #region StudentID
    public static readonly DependencyProperty StudentIDProperty = DependencyProperty.Register("StudentID", typeof(String), typeof(ViewStudent), new PropertyMetadata(OnStudentIDChanged));
    public string StudentID
    {
        get { return (string)GetValue(StudentIDProperty); }
        set { SetValue(StudentIDProperty, value); }
    }
    static void OnStudentIDChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as ViewStudent).OnStudentIDChanged(e);
    }
    void OnStudentIDChanged(DependencyPropertyChangedEventArgs e)
    {
        groupBox1.Header = StudentID;
        textBlock1.Text = StudentID;
    }
    #endregion
