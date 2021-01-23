            var cloudWatchClient = AWSClientFactory.CreateAmazonCloudWatchClient(RegionEndpoint.USWest2);
            var describeAlarmsResponse = cloudWatchClient.DescribeAlarms(new DescribeAlarmsRequest
            {
                AlarmNames = { "the_name_of_your_alarm" }
            });
            var describeAlarmsResult = describeAlarmsResponse.DescribeAlarmsResult;
            foreach (var alarm in describeAlarmsResult.MetricAlarms)
            {
                Console.WriteLine("Alarm State = " + alarm.StateValue);
                Console.WriteLine("Alarm State Reason = " + alarm.StateReason);
                Console.WriteLine("Alarm JSON Data = " + alarm.StateReasonData);
            }
