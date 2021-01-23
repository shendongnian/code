        Public Class TextBoxLog
        Inherits Freezable
        Implements WPFGlue.Framework.IStickyComponent
        Private _AppendTextDelegate As Action(Of String)
        Private _ScrollToEndDelegate As Action
        Private _ResetDelegate As Action
        Public Shared ReadOnly LogProperty As DependencyProperty = DependencyProperty.RegisterAttached("Log", GetType(TextBoxLog), GetType(TextBoxLog), New PropertyMetadata(AddressOf WPFGlue.Framework.StickyComponentManager.OnStickyComponentChanged))
        Public Shared Function GetLog(ByVal d As DependencyObject) As TextBoxLog
            Return d.GetValue(LogProperty)
        End Function
        Public Shared Sub SetLog(ByVal d As DependencyObject, ByVal value As TextBoxLog)
            d.SetValue(LogProperty, value)
        End Sub
        Public Shared ReadOnly LogMessageProperty As DependencyProperty = DependencyProperty.Register("LogMessage", GetType(String), GetType(TextBoxLog), New PropertyMetadata(AddressOf OnLogMessageChanged))
        Public Property LogMessage As String
            Get
                Return GetValue(LogMessageProperty)
            End Get
            Set(ByVal value As String)
                SetValue(LogMessageProperty, value)
            End Set
        End Property
        Private Shared Sub OnLogMessageChanged(ByVal d As TextBoxLog, ByVal e As DependencyPropertyChangedEventArgs)
            If e.NewValue IsNot Nothing Then
                d.WriteLine(e.NewValue)
            End If
        End Sub
        Protected Overridable Sub Attach(base As Object)
            If Not TypeOf base Is System.Windows.Controls.Primitives.TextBoxBase Then
                Throw New ArgumentException("Can only be attached to elements of type TextBoxBase")
            End If
            Dim tb As System.Windows.Controls.Primitives.TextBoxBase = base
            _AppendTextDelegate = AddressOf tb.AppendText
            _ScrollToEndDelegate = AddressOf tb.ScrollToEnd
            _ResetDelegate = AddressOf Me.Reset
        End Sub
        Protected Overridable Sub Detach(ByVal base As Object)
            _AppendTextDelegate = Nothing
            _ScrollToEndDelegate = Nothing
            _ResetDelegate = Nothing
        End Sub
        Private Sub Reset()
            SetCurrentValue(LogMessageProperty, Nothing)
        End Sub
        Protected Overrides Function CreateInstanceCore() As System.Windows.Freezable
            Return New TextBoxLog
        End Function
        Public Overridable Sub Write(message As String)
            If _AppendTextDelegate IsNot Nothing Then
                _AppendTextDelegate.Invoke(message)
                _ScrollToEndDelegate.Invoke()
                '               Me.Dispatcher.Invoke(_ResetDelegate, Windows.Threading.DispatcherPriority.Background)
            End If
        End Sub
        Public Overridable Sub WriteLine(message As String)
            If _AppendTextDelegate IsNot Nothing Then
                _AppendTextDelegate.Invoke(message)
                _AppendTextDelegate.Invoke(vbNewLine)
                _ScrollToEndDelegate.Invoke()
                '                Me.Dispatcher.Invoke(_ResetDelegate, Windows.Threading.DispatcherPriority.Background)
            End If
        End Sub
        Public ReadOnly Property Mode As Framework.AttachMode Implements Framework.IStickyComponent.Mode
            Get
                Return Framework.AttachMode.Immediate
            End Get
        End Property
        Public Sub OnAttach(base As Object, e As System.EventArgs) Implements Framework.IStickyComponent.OnAttach
            If e Is System.EventArgs.Empty Then
                Attach(base)
            End If
        End Sub
        Public Sub OnDetach(base As Object, e As System.EventArgs) Implements Framework.IStickyComponent.OnDetach
            If e Is System.EventArgs.Empty Then
                Detach(base)
            End If
        End Sub
    End Class
