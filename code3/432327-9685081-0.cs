	#Region "IErrorHandler Members"
	Public Function HandleError(ByVal [error] As Exception) As Boolean Implements IErrorHandler.HandleError
	  Console.WriteLine("HandleError called.")
	  ' Returning true indicates you performed your behavior.
	  Return True
	End Function
	' This is a trivial implementation that converts Exception to FaultException<GreetingFault>.
	Public Sub ProvideFault(ByVal [error] As Exception, ByVal ver As MessageVersion, ByRef msg As Message) Implements IErrorHandler.ProvideFault
	  Console.WriteLine("ProvideFault called. Converting Exception to GreetingFault....")
	  Dim fe As New FaultException(Of GreetingFault)(New GreetingFault([error].Message))
	  Dim fault As MessageFault = fe.CreateMessageFault()
	  msg = Message.CreateMessage(ver, fault, "http://microsoft.wcf.documentation/ISampleService/SampleMethodGreetingFaultFault")
	End Sub
	#End Region
