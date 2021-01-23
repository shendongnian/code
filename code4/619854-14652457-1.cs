     Mapper.CreateMap<EventDTO, Event>()
                ....
                .AfterMap((source, dest) =>
                              {
                                  switch (dest.EventType)
                                  {
                                      case 1:
                                          // Behaviour EventType 1
                                          ...
                                          dest.Name = source.NameDTO + "1";
                                          ...
                                          break;
                                      case 2:
                                          // Behaviour EventType 2
                                          ...
                                          dest.Name = source.NameDTO + "2";
                                          ...
                                          break;
                                      default:
                                          // Behaviour EventType 3
                                          ...
                                          dest.Name = source.NameDTO + "0";
                                          ...
                                          break;
                                  }
                              });
