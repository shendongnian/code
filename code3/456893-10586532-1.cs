             /**
			 * get the adjustment rules for the selected timezone.
			 * the adjustment rule is the Daylight Savings adjustment by default.
			 * using the i to note the most recent rule.
			 * DateStart and .DateEnd designate the begin and end of the rule.
			 * DaylightTransitionStart and End designate the begin and end date of DST.
			 * DayLightDelta is the difference between base UTC and the offset by DS, add to get DS value from Base.
			 **/
			if (timezone.SupportsDaylightSavingTime)
			{
				TimeZoneInfo.AdjustmentRule[] adjustments = timezone.GetAdjustmentRules();
				int i = adjustments.Length - 1;
				string body = string.Format(vTimeZoneTemplate1
					, timezone.Id
					, adjustments[i].DateStart.ToString(DateTimeFormat)
					, timezone.BaseUtcOffset
					, adjustments[i].DaylightDelta.Add(timezone.BaseUtcOffset)
					, timezone.DaylightName
					, timezone.StandardName
					, adjustments[i].DateEnd.ToString(DateTimeFormat)
					, adjustments[i].DaylightTransitionStart.Month.ToString("MM")
					, adjustments[i].DaylightTransitionEnd.Month.ToString("MM")
					, adjustments[i].DaylightTransitionStart.Week.ToString()
					, adjustments[i].DaylightTransitionEnd.Week.ToString()
					, adjustments[i].DaylightTransitionStart.IsFixedDateRule
						? adjustments[i].DaylightTransitionStart.Day.ToString().Substring(0, 2) 
						: adjustments[i].DaylightTransitionStart.DayOfWeek.ToString().Substring(0, 2)
					, adjustments[i].DaylightTransitionEnd.IsFixedDateRule
						? adjustments[i].DaylightTransitionEnd.Day.ToString().Substring(0, 2)
						: adjustments[i].DaylightTransitionEnd.DayOfWeek.ToString().Substring(0, 2)) +
					string.Format(vEventTemplate
						, timezone.Id
						, startDate
						, endDate
						, summary
						, description
						, Guid.NewGuid().ToString()
						, sequence
						, DateTime.Now.ToString(DateTimeFormat)
						, vCalAttendees.ToString()
						, organizer.FullName
						, organizer.Email
						, location
						, string.IsNullOrEmpty(this.DescriptionHtml) ? string.Empty : string.Format("X-ALT-DESC;FMTTYPE=text/html:{0}", Email.WrapHTMLBody(this.DescriptionHtml, false, false))) +
					(enableReminder ? vAlarmTemplate : string.Empty);
				return string.Format(baseVCalTemplate, body);
			}
			else
			{
				string body = string.Format(vTimeZoneTemplate2
					, timezone.Id
					, timezone.BaseUtcOffset
					, timezone.DisplayName) +
					string.Format(vEventTemplate
						, timezone.Id
						, startDate
						, endDate
						, summary
						, description
						, Guid.NewGuid().ToString()
						, sequence
						, DateTime.Now.ToString(DateTimeFormat)
						, vCalAttendees.ToString()
						, organizer.FullName
						, organizer.Email
						, location
						, string.IsNullOrEmpty(this.DescriptionHtml) ? string.Empty : string.Format("X-ALT-DESC;FMTTYPE=text/html:{0}", Email.WrapHTMLBody(this.DescriptionHtml, false, false))) +
					(enableReminder ? vAlarmTemplate : string.Empty);
				return string.Format(baseVCalTemplate, body);
			}
		}
