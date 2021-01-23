                    AmazonEC2 ec2 = AWSClientFactory.CreateAmazonEC2Client();
                    //Create instance request
                    DescribeInstancesRequest request = new DescribeInstancesRequest();
                    DescribeInstancesResponse response = ec2.DescribeInstances(request);
                    //Create ip address request enumeration
                    DescribeAddressesRequest daRequest = new DescribeAddressesRequest();
                    DescribeAddressesResponse daResponse = ec2.DescribeAddresses(daRequest);
                    var publicIps = from ips in daResponse.DescribeAddressesResult.Address select ips.PublicIp;
                    //List of the instances which has public IP
                    List<RunningInstance> publicIpInstances = new List<RunningInstance>();
                    //Iterate over instances and check if they have public IP
                    foreach (Reservation ri in response.DescribeInstancesResult.Reservation)                    
                        publicIpInstances.AddRange(ri.RunningInstance.Where(inst => publicIps.Contains(inst.IpAddress)));
