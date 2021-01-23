    foreach (Customer name in m_customers) 
    { 
        if(name.ContactData != null) System.Diagnostics.Debug.WriteLine(name.ContactData.FullName);
    
        if (name.ContactData.FullName == "Anna")  
        { 
            MessageBox.Show(string.Format("Yes"), "Test!", MessageBoxButtons.OK, MessageBoxIcon.Information); // Just for testing   
        } 
    } 
