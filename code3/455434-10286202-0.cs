    var factoryMethod = new Func<string, IRobot>(nameOfRobot =>
                            {
                                if (nameOfRobot == "Maximilian")
                                {
                                    return _ninjectKernel.Get<KillerRobot>();
                                }
                                else
                                {
                                    return _ninjectKernel.Get<StandardRobot>();
                                }
                            });
    _ninjectKernel.Bind<Func<string, IRobot>>().ToConstant(factoryMethod);
