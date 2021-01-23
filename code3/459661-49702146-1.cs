    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Tweetinvi;
    using Tweetinvi.Models;
    
    namespace APIS
    {
        public class TwitterConfig
        {
            IAuthenticationContext authenticationContext;
    
            /// <summary>
            /// Le indica a twitter que va a hacer una consulta de crendenciales. Esta consulta va a generar un PIN en caso de que sea correcto
            /// y el usuario tiene que digitar el pin.
            /// </summary>
            public void RequestForCredentials()
            {
                var appCredentials = new TwitterCredentials("CONSUMER-KEY", "CONSUMER-SECRET"); //GET THE CONSUMER INFORMATION ON THE TWITTER APP MANAGEMENT
                
                authenticationContext = AuthFlow.InitAuthentication(appCredentials);
                
                
                //This opens a web-browser and asks to the twitter client 
                //to accept the terms, and twitter gives a code and the user
                // have to introduce it on the app (use the AuthByPin(String pin) method )
                //Thats the PIN for auth the user and then get the data
                Process.Start(authenticationContext.AuthorizationURL);
            }
    
            /// <summary>
            /// Metodo que solicita un PIN que un usuario de Twitter al aceptar las condiciones se le brindó y este lo introdujo en la app
            /// para ser autenticado.
            /// </summary>
            /// <param name="pin">PIN del usuario</param>
            /// <returns>IAuthenticatedUser devuelve el usuario autenticado y con todos los datos.</returns>
            public IAuthenticatedUser AuthByPin(String pin) 
            {
                try
                {
                    // Con este código PIN ahora es posible recuperar las credenciales de Twitter 
                    var userCredentials = AuthFlow.CreateCredentialsFromVerifierCode(pin, authenticationContext);
                    
                    // Use las credenciales del usuario en su aplicación 
                    Auth.SetCredentials(userCredentials);
    
                    var user = User.GetAuthenticatedUser();
                    return user; 
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw new ApplicationException("Problema al autenticar.", e);
                }
            }
        }
    }
    </code>
