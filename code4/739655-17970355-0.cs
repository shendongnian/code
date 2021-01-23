    Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
		AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf Me.OnAssemblyResolveHandler
	End Sub
	Private Function OnAssemblyResolveHandler(sender As Object, args As ResolveEventArgs) As System.Reflection.Assembly
		If args.Name.StartsWith("assemblyName,") Then Return System.Reflection.Assembly.LoadFrom(@"pathOf3rdPartyAssembly")
		Return Nothing
	End Function
