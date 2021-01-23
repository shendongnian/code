                    ///check if we have a compatible type defined in chosen  file?
                    Type compatibleType = types.SingleOrDefault(x => typeof(MyInterface).IsAssignableFrom(x));
                    if (compatibleType != null)
                    {
                        ///if the compatible type exists then we can proceed and create an instance of a platform
                        found = true;
                        //create an instance here
                        MyInterface obj = (ALPlatform)AreateInstance(compatibleType);
                    }
