    if (new basics.HindiMessageBox(HMsg, HTitle).ShowDialog()==true)
    {
        SQLiteConnection m_dbConnection = new SQLiteConnection(MainWindow.con);
        m_dbConnection.Open();
        sql = "DELETE FROM `users`  WHERE `id`=" + SelectedUser.Id;
        command = new SQLiteCommand(sql, m_dbConnection);
        command.ExecuteNonQuery();
        m_dbConnection.Close();
        LoadUserDG();
    }
