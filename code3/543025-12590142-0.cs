    <behaviors>
       <serviceBehaviors>
         <behavior name="YourCustomBehavior">
           <serviceDebug includeExceptionDetailInFaults="true" />
           <serviceCredentials type="Your.Namespace.PasswordServiceCredentials, Your.Namespace">
             <serviceCertificate findValue="localhost" x509FindType="FindBySubjectName" />
             <userNameAuthentication userNamePasswordValidationMode="Custom" />
           </serviceCredentials>
           <serviceAuthorization principalPermissionMode="Custom" />
         </behavior>
       </serviceBehaviors>
     </behaviors> 
