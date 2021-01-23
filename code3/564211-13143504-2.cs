                .Select(evntInfo => {
                    evntInfo.TheEvent.ActualAssessment = evntInfo.ActualAssessment;
                    return new ExtendedEvent {
                        TheEvent = evntInfo.TheEvent,
                        SomeExtraData = evntInfo.SomeExtraData
                    };
                })
