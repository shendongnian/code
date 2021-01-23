     public static void HandleFault(Message message) {
            MessageFault fault = MessageFault.CreateFault(message, Int32.MaxValue);
            //Let the fault exception choose the best fault to handle?
            System.ServiceModel.FaultException faultexcept = System.ServiceModel.FaultException.CreateFault(fault,
                typeof(PermissionDeniedFault),
                typeof(AuthenticationRequiredFault),
                typeof(AuthorizationRequiredFault),
                typeof(EndpointUnavailable),
                typeof(FragmentDialectNotSupported),
                typeof(InvalidRepresentationFault),
                typeof(UnwillingToPerformFault),
                typeof(CannotProcessFilter),
                typeof(FilterDialectRequestedUnavailable),
                typeof(UnsupportedExpiration),
                typeof(AnonymousInteractionRequiredFault),
                typeof(RepresentationFailures)
            );
            try
            {
                throw faultexcept;
            }
            catch (System.ServiceModel.FaultException<RepresentationFailures> invalidRepresentationFault)
            {
                throw new Exception(
                    String.Format(
                        "{0}\r\nfor Attribute \"{1}\" with Value \"{2}\"",
                            invalidRepresentationFault.Detail.AttributeRepresentationFailure.AdditionalTextDetails,
                            invalidRepresentationFault.Detail.AttributeRepresentationFailure.AttributeType,
                            invalidRepresentationFault.Detail.AttributeRepresentationFailure.AttributeValue
                        ),
                     invalidRepresentationFault
                 );
            }
            catch (System.ServiceModel.FaultException otherFault)
            {
                throw otherFault;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
