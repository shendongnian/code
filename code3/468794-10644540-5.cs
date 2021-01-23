                public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
                {
                    if (binder.Name == "ContainsKey")
                    {
                        result = _dictionary.ContainsKey(args[0] as string);
                        return true;
                    }
                    else
                    {
                        return base.TryInvokeMember(binder, args, out result);
                    }
                }
