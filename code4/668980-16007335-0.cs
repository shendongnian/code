    //Test Window
    public partial class Test : Window
    {
        Student loadedStudent = new Student();
        public TeacherTools teachTools { get; set; }
        ...
    }
    //Main Window
    public partial class MainWindow : Window
    {
        ...
    
        private void Selection_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            myTest.teachTools = this.teachTools;
            myTest.ShowDialog();
            this.Show();
        }
    }
