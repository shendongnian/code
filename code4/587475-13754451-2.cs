    Partial Class Default
      Inherits System.Web.UI.Page
      Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
          If Not Page.IsPostBack Then
              Dim itemList As List(Of ListItem) = ClassForTheMagic.GetItemsForComboBox(txtBox1.Text, checkBox2.check, ...)
              For Each item As ListItem In itemList
                  DropDownList1.Items.Add(item)
              Next
          End If
      End Sub
