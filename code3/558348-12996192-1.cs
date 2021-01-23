    Button button = sender as Button;
    string buttonIndex = button.Name.Substring(6);
    string tempEmail = (this.Controls["tb" + buttonIndex] as TextBox).Text;
    string tmpNickName = (this.Controls["tbNickName" + buttonIndex] as TextBox).Text;
    string tmpGroup = (this.Controls["comboBox" + buttonIndex] as ComboBox).Text;
