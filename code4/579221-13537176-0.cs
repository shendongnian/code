    Public Class Form1
    Private Weapons As New List(Of Weapon)
    
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Weapons
            .Add(New Weapon("M16", ".223"))
            .Add(New Weapon("AK74", "7.62"))
            .Add(New Weapon("Catapult", "Pumpkin"))
        End With
        Me.ComboBox1.DataSource = Weapons
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim w As Weapon = DirectCast(ComboBox1.SelectedItem, Weapon)
            Debug.Print("A {0} needs some {1} to be effective!", w.Name, w.Ammo)
        End If
    End Sub
    End Class
    Public Class Weapon
    Public Name As String
    Public Ammo As String
    Public Sub New(Name As String, Ammo As String)
        Me.Name = Name
        Me.Ammo = Ammo
    End Sub
    Public Overrides Function ToString() As String
        Return Me.Name
    End Function
    End Class
