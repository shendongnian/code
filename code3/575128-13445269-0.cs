    var orderedEvents = orderIds.Join(
                         //Construct Groups 
                         events.GroupBy( e => e.Id)
                               .GroupJoin( Events_before_after,
                                           g => g.Key,
                                           e => e.EventId,
                                           (gEvent, gEventBA) => new { Key = gEvent.Key,
                                           EventGroup = 
                                           gEvent.Select( e => new DataEvent ()
                                                         {
                                                          eventId = e.Id,
                                                          start = e.start,
                                                          end = e.end,
                                                          type = e.type
                                                         })
                                                  .Concat( gEventBA.Select( e => new DataEvent ()
                                                                    {
                                                                     eventId = e.Id,
                                                                     start = e.start,
                                                                     end = e.end,
                                                                     type = e.type
                                                                    }))
                                                  .OrderBy(e => e.eventId)),
                          //Project along keys
                          o => o,
                          anon => anon.Key,
                          (o,anon) => anon.EventGroup)
                          //Flatten groups
                               .SelectMany( g => g);
