    Imports Microsoft.Practices.Unity
    Imports Microsoft.Practices.Unity.Configuration
    Imports Microsoft.Practices.ServiceLocation
    	Private Sub InitServiceLocator()
    		Dim container As IUnityContainer = New UnityContainer()
    		container.LoadConfiguration() //read xml config
             //container.RegisterType<Of ...>(...) //config in runtime instead in xml
    		Dim provider = New UnityServiceLocator(container)
    		ServiceLocator.SetLocatorProvider(Function() provider)
    	End Sub
