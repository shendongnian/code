                IContextChannel contextChannel = (IContextChannel)myServiceProxy;
                using (OperationContextScope scope = new OperationContextScope(contextChannel))
                {
                    MessageHeader header = MessageHeader.CreateHeader("PlayerId", "", _playerId);
                    OperationContext.Current.OutgoingMessageHeaders.Add(header);
                    act(service);
                }
