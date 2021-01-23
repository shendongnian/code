    <behaviors>
          <serviceBehaviors>
            <behavior name="ServiceBehavior">
                <serviceCredentials>
                  <userNameAuthentication userNamePasswordValidationMode="Custom" customUserNamePasswordValidatorType="Microsoft.ServiceModel.Samples.CalculatorService.CustomUserNameValidator, service" />
                </serviceCredentials>
             .....
             </serviceBehaviors>
    </behaviors> 
