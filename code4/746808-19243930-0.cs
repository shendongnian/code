    <TypeConverter(GetType(ImageKeyConverter))> _
    <RelatedImageList("LoadingImageList")> _
    <Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design", GetType(Drawing.Design.UITypeEditor))> _
    <Description("Imagen de carga que se mostrará en el control cuando se indique.")> _
    Public Property LoadingImageKey() As String
        Get
            Return sPic
        End Get
        Set(ByVal value As String)
            sPic = value
        End Set
    End Property
