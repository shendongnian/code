     foreach (Topic topic in result)
     {
       string topicName = topic.TopicArn.ToString().Split(':').Last();
       ListItem li = new ListItem(topicName, topic.TopicArn);
       checkBoxList1.Items.Add(li); 
     }
     int i = 0;
     foreach (Subscription subscription in subs)                                  
     {
             if (txtEmail.Text == subscription.Endpoint)
                 checkBoxList1.Items[i].Selected = true;
       i++;
     }
 
