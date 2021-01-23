    using (RMPortalEntities _RMPortalEntities = new RMPortalEntities()) {
                var GUID = new Guid(_RMPortalEntities.tbl_RSVP_ButtonLocation.ID);
                var _RSVP_ButtonLocations = _RMPortalEntities
                                            .tbl_RSVP_ButtonLocation
                                            .Join(_RMPortalEntities.tbl_RSVP_Setting,
                                                            _RSVP_ButtonLocation => GUID,
                                                            _RSVP_Setting => _RSVP_Setting.RSVP_Button_Location_ID,
                                                            (_RSVP_ButtonLocation, _RSVP_Setting) => new { _RSVP_ButtonLocation, _RSVP_Setting })
                                            .Join(_RMPortalEntities.tbl_Event,
                                                            _RSVP_ButtonLocation_RSVP_Setting => _RSVP_ButtonLocation_RSVP_Setting._RSVP_Setting.EventID,
                                                            _Event => _Event.ID,
                                                            (_RSVP_ButtonLocation_RSVP_Setting, _Event) => new { _RSVP_ButtonLocation_RSVP_Setting, _Event })
                                            .Where(x => x._Event.Active == true
                                                        && x._Event.ID == _EventID)
                                            .Select(x => new
                                            {
                                                RSVP_ButtonLocations = x._RSVP_ButtonLocation_RSVP_Setting._RSVP_ButtonLocation.RSVP_ButtonLocation
                                            });
                return _RSVP_ButtonLocations.FirstOrDefault().RSVP_ButtonLocations;
            }
