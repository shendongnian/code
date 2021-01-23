    barMock.AssertWasCalled(x => 
                  x.Add(Arg<UIDClass>.Is.Matching(
                        delegate(UIDClass u) { return u.Value == uid.Value; }
                  ), 
                  ref Arg<object>.Ref(Is.Same(input), output).Dummy);
