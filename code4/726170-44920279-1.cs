        public partial class User : Window
        {
    
            SQLiteCommand command;
            string sql;
            AddUser AddUserObj;
            List<basics.users> usersList;
            basics.users SelectedUser;
            SQLiteConnection m_dbConnection;
    .....
    .....
    .....
    .....
           private void DeleteBtn_Click(object sender, RoutedEventArgs e)
            {
                ....
                ....
                ....
                if (new basics.HindiMessageBox(HMsg, HTitle).ShowDialog()==true)
                {
                    m_dbConnection = new SQLiteConnection(MainWindow.con);
                    m_dbConnection.Open();
                    sql = "DELETE FROM `users`  WHERE `id`=" + SelectedUser.Id;
                    command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();
                    m_dbConnection.Close();
                    LoadUserDG();
                }
            }
