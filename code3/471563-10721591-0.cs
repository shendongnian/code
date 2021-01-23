Use the is and as operators.
            List<IMachines> mList =new List<IMachines>();
            IMachines machine = mList.Where(x => x.Name == "MachineName").FirstOrDefault();
            if (machine != null)
            {
                if (machine is Generator)
                {
                    Generator generator = machine as Generator;
                    //do something with generator
                }
                else if (machine is AC)
                {
                    AC ac = machine as AC;
                    //do something with ac
                }
                else
                {
                    //do you other kinds? if no, this is never going to happen
                    throw new Exception("Unsupported machine type!!!");
                }
            }
