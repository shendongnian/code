    Public ReadOnly Property AudioCodecs() As IEnumerable(Of CodecInfo)
    	Get
    		Return softPhone.Codecs.Where(Function(c) c.CodecType = CodecMediaType.Audio)
    	End Get
    End Property
