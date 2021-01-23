    private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
       // Get the currently selected item in the ListBox.
       string curItem = comboBox1.SelectedItem.ToString();
       string sqlText = "SELECT EmployeeID, FirstName, LastName, MaritalStatus, Gender " + 
                        "FROM Employes JOIN Contacts ON Employes.ContactId = Contacts.ContactID "
       switch(curItem)
       {
          case "Femmes":
              sqlText += "AND Gender = 'F' ORDER BY LastName, FirstName";
              break;
          case "Hommes":
              sqlText += "AND Gender = 'M' ORDER BY LastName, FirstName";
              break;
          default:
              sqlText += "ORDER BY LastName, FirstName";
       }
       DataTable dt = GetEmployeeList(sqlText);
       ...... // Now fill the datasource of your grid
    }
