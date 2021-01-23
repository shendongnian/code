	Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
		contactsBindingSource.EndEdit()
		contactsTableAdapter.Update(contactsTable)
		contactsTable = contactsTableAdapter.GetData()
	End Sub
	Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
		contactsBindingSource.CancelEdit()
		contactsTable = contactsTableAdapter.GetData()
	End Sub
