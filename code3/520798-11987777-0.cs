    Public ReadOnly Property AudioCodecs As IEnumerable(Of CodecInfo)
        Get
            Return From c In softPhone.Codecs
                   Where c.CodecType = CodecMediaType.Audio
        End Get
    End Property
