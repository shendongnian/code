    registration.ForTypesDerivedFrom<TestStepResult>()
       .Export<TestStepResult>()
       .SelectConstructor(ctorInfos => 
                          {
                              var parameterLessCtor = ctorInfos.FirstOrDefault(ci => ci.GetParameters().Length == 0);
                              if (parameterLessCtor != null)
                                  return parameterLessCtor;
                              else
                                  return ctorInfos.First();
                          });
