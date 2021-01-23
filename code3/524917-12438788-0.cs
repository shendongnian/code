    Imports System.ComponentModel
    Imports System.Windows.Forms
    Imports Office2003
    Imports System.Drawing
    Imports System.Windows.Forms.Design
    
    Public Class MyUserControl
        Private _Buttons As MyUserControlButtons
        Public Event MyUserControlButtonClicked(ByVal Sender As MyUserControlButton)
    
        Public Sub New()
            MyBase.New()
    
            'This call is required by the Component Designer.
            InitializeComponent()
    
            _Buttons = New MyUserControlButtons(MyToolStrip)
        End Sub
    
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property Buttons As MyUserControlButtons
            Get
                Return _Buttons
            End Get
        End Property
    
        Private Sub MyToolStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MyToolStrip.ItemClicked
    	 'Check if the ToolStrip item clicked is a ToolStripButton...
            If TypeOf e.ClickedItem Is ToolStripButton Then
                'Insert your code here...
    
    	     'Raise the custom event.
                RaiseEvent MyUserControlButtonClicked(Item)
            End If
        End Sub
    End Class
    
    #Region "Manager classes for MyUserControl buttons."
    
    Public Class MyUserControlButtons
        Inherits CollectionBase
        Private _Parent As ToolStrip
    
        ''' <summary>
        ''' Initializes a new instance of the MyUserControlButtons class.
        ''' </summary>
        ''' <param name="Holder">The ToolStrip that contains the items of the MyUserControlButtons class.</param>
        Public Sub New(ByVal Holder As ToolStrip)
            MyBase.New()
            _Parent = Holder
        End Sub
    
        ''' <summary>
        ''' The ToolStrip that contains this item.
        ''' </summary>
        Public ReadOnly Property Parent() As ToolStrip
            Get
                Return _Parent
            End Get
        End Property
    
        ''' <summary>
        ''' Gets the element at the specified index.
        ''' </summary>
        ''' <param name="Index">The zero-based index of the element to get.</param>
        Default Public ReadOnly Property Item(ByVal Index As Integer) As MyUserControlButton
            Get
                Return CType(List(Index), MyUserControlButton)
            End Get
        End Property
    
        ''' <summary>
        ''' Adds an item to the collection.
        ''' </summary>
        Public Function Add() As MyUserControlButton
            Return Me.Add
        End Function
    
        ''' <summary>
        ''' Adds an item to the collection.
        ''' </summary>
        ''' <param name="Value">The object to add to the collection.</param>
        Public Sub Add(ByVal Value As MyUserControlButton)
            List.Add(Value)
            Value.Parent = Me.Parent
        End Sub
    
        ''' <summary>
        ''' Adds an item to the collection.
        ''' </summary>
        ''' <param name="Name">The name of the object to add to the collection.</param>
        ''' <param name="Image">The image of the object to add to the collection.</param>
        Public Function Add(ByVal Name As String, ByVal Image As Image) As MyUserControlButton
            Dim b As MyUserControlButton = New MyUserControlButton(Me.Parent)
            b.Name = Name
            b.Text = Name
            b.Image = Image
            Me.Add(b)
            Return b
        End Function
    
        ''' <summary>
        ''' Adds an item to the collection.
        ''' </summary>
        ''' <param name="Name">The name of the object to add to the collection.</param>
        ''' <param name="Text">The text of the object to add to the collection.</param>
        ''' <param name="Image">The image of the object to add to the collection.</param>
        Public Function Add(ByVal Name As String, ByVal Text As String, ByVal Image As Image) As MyUserControlButton
            Dim b As MyUserControlButton = New MyUserControlButton(Me.Parent)
            b.Name = Name
            b.Text = Text
            b.Image = Image
            Me.Add(b)
            Return b
        End Function
    
        ''' <summary>
        ''' Removes the first occurence of a specific object from the collection.
        ''' </summary>
        ''' <param name="Value">The object to be removed.</param>
        Public Sub Remove(ByVal Value As MyUserControlButton)
            List.Remove(Value)
        End Sub
    
        ''' <summary>
        ''' Determines the index of a specific item in the collection.
        ''' </summary>
        ''' <param name="Value">The object to locate in the collection.</param>
        Public Function IndexOf(ByVal Value As Object) As Integer
            Return List.IndexOf(Value)
        End Function
    
        ''' <summary>
        ''' Determines whether the collection contains a specific value.
        ''' </summary>
        ''' <param name="Value">The object to locate in the collection.</param>
        Public Function Contains(ByVal Value As MyUserControlButton) As Boolean
            Return List.Contains(Value)
        End Function
    
        Protected Overrides Sub OnInsertComplete(ByVal index As Integer, ByVal value As Object)
            Dim b As MyUserControlButton = CType(value, MyUserControlButton)
            b.Parent = Me.Parent
            Me.Parent.Items.Insert(index, CType(value, ToolStripButton))
            MyBase.OnInsertComplete(index, value)
        End Sub
    
        Protected Overrides Sub OnSetComplete(ByVal index As Integer, ByVal oldValue As Object, ByVal newValue As Object)
            Dim b As MyUserControlButton = CType(newValue, MyUserControlButton)
            b.Parent = Me.Parent
            MyBase.OnSetComplete(index, oldValue, newValue)
        End Sub
    
        Protected Overrides Sub OnClearComplete()
            MyBase.OnClearComplete()
        End Sub
    End Class
    
    Public Class MyUserControlButton
        Inherits ToolStripButton
    
        ''' <summary>
        ''' Initializes a new instance of the MyUserControlButton class.
        ''' </summary>
        Sub New()
            MyBase.New()
            Init()
        End Sub
    
        ''' <summary>
        ''' Initializes a new instance of the MyUserControlButton class.
        ''' </summary>
        ''' <param name="Holder">The ToolStrip that contains the StackView button.</param>
        Sub New(ByVal Holder As ToolStrip)
            MyBase.New()
            Init()
            Me.Parent = Holder
        End Sub
    
        Private Sub Init()
            Me.AutoToolTip = False
            Me.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            Me.ImageAlign = ContentAlignment.MiddleLeft
            Me.ImageIndex = -1
            Me.ImageKey = ""
            Me.ImageTransparentColor = Color.Magenta
            Me.TextAlign = ContentAlignment.MiddleLeft
            Me.TextDirection = ToolStripTextDirection.Horizontal
        End Sub
    
        ''' <remarks>
        ''' Hide this property from the user in both design and code editor.
        ''' </remarks>
        <Browsable(False),
        EditorBrowsable(False)> _
        Public Shadows Property AccessibleDefaultActionDescription As String
            Get
                Return MyBase.AccessibleDefaultActionDescription
            End Get
            Set(ByVal value As String)
                MyBase.AccessibleDefaultActionDescription = value
            End Set
        End Property
    
        ''' <remarks>
        ''' Hide this property from the user in both design and code editor.
        ''' </remarks>
        <Browsable(False),
        EditorBrowsable(False)> _
        Public Shadows Property AccessibleDescription As String
            Get
                Return MyBase.AccessibleDescription
            End Get
            Set(ByVal value As String)
                MyBase.AccessibleDescription = value
            End Set
        End Property
    
        ''' <remarks>
        ''' Hide this property from the user in both design and code editor.
        ''' </remarks>
        <Browsable(False),
        EditorBrowsable(False)> _
        Public Shadows Property AccessibleName As String
            Get
                Return MyBase.AccessibleName
            End Get
            Set(ByVal value As String)
                MyBase.AccessibleName = value
            End Set
        End Property
    
    
        ' Keep on hiding the irrelevant properties...
    
    
        ''' <summary>
        ''' Gets or sets a value indicating whether default or custom ToolTip text is displayed on the ToolStripButton.
        ''' </summary>
        <DefaultValue(False)> _
        Public Shadows Property AutoToolTip As Boolean
            Get
                Return MyBase.AutoToolTip
            End Get
            Set(ByVal value As Boolean)
                MyBase.AutoToolTip = value
            End Set
        End Property
    
        ''' <summary>
        ''' Specifies whether the image and text are rendered.
        ''' </summary>
        <DefaultValue(GetType(ToolStripItemDisplayStyle), "ImageAndText")> _
        Public Overrides Property DisplayStyle As System.Windows.Forms.ToolStripItemDisplayStyle
            Get
                Return MyBase.DisplayStyle
            End Get
            Set(ByVal value As System.Windows.Forms.ToolStripItemDisplayStyle)
                MyBase.DisplayStyle = value
            End Set
        End Property
    
        ''' <summary>
        ''' The image that will be displayed on the control.
        ''' </summary>
        Public Overrides Property Image() As Image
            Get
                Return MyBase.Image
            End Get
            Set(ByVal value As Image)
                MyBase.Image = value
            End Set
        End Property
    
        ''' <summary>
        ''' Gets or sets the alignment of the image on a ToolStripItem.
        ''' </summary>
        <DefaultValue(GetType(ContentAlignment), "MiddleLeft")> _
        Public Shadows Property ImageAlign As ContentAlignment
            Get
                Return MyBase.ImageAlign
            End Get
            Set(ByVal value As ContentAlignment)
                MyBase.ImageAlign = value
            End Set
        End Property
    
        <EditorBrowsable(False),
        DefaultValue(-1)> _
        Public Shadows Property ImageIndex As Integer
            Get
                Return MyBase.ImageIndex
            End Get
            Set(ByVal value As Integer)
                MyBase.ImageIndex = value
            End Set
        End Property
    
        <EditorBrowsable(False),
        DefaultValue("")> _
        Public Shadows Property ImageKey As String
            Get
                Return MyBase.ImageKey
            End Get
            Set(ByVal value As String)
                MyBase.ImageKey = value
            End Set
        End Property
    
        ''' <summary>
        ''' Gets or sets the color to treat as transparent in a ToolStripItem image.
        ''' </summary>
        Public Shadows Property ImageTransparentColor As Color
            Get
                Return MyBase.ImageTransparentColor
            End Get
            Set(ByVal value As Color)
                MyBase.ImageTransparentColor = value
            End Set
        End Property
    
        ''' <summary>
        ''' Specifies the name used to identify the object.
        ''' </summary>
        Public Shadows Property Name() As String
            Get
                Return MyBase.Name
            End Get
            Set(ByVal value As String)
                MyBase.Name = value
            End Set
        End Property
    
        ''' <summary>
        ''' The ToolStrip that contains this item.
        ''' </summary>
        <Browsable(False)> _
        Public Shadows Property Parent As ToolStrip
            Get
                Return MyBase.Parent
            End Get
            Set(ByVal value As ToolStrip)
                MyBase.Parent = value
            End Set
        End Property
    
        ''' <summary>
        ''' The text that will be displayed on the control.
        ''' </summary>
        Public Overrides Property Text() As String
            Get
                Return MyBase.Text
            End Get
            Set(ByVal value As String)
                MyBase.Text = value
            End Set
        End Property
    
        ''' <summary>
        ''' Gets or sets the alignment of the text on a ToolStripLabel.
        ''' </summary>
        <DefaultValue(GetType(ContentAlignment), "MiddleLeft")> _
        Public Overrides Property TextAlign As ContentAlignment
            Get
                Return MyBase.TextAlign
            End Get
            Set(ByVal value As ContentAlignment)
                MyBase.TextAlign = value
            End Set
        End Property
    
        <Browsable(False),
        EditorBrowsable(False),
        DefaultValue(GetType(ToolStripTextDirection), "Horizontal")> _
        Public Overrides Property TextDirection As ToolStripTextDirection
            Get
                Return MyBase.TextDirection
            End Get
            Set(ByVal value As ToolStripTextDirection)
                MyBase.TextDirection = value
            End Set
        End Property
    
    
        ' Define other properties accordingly...
    End Class
    
    #End Region
