     public partial class TopicSubTopic {
        public TopicSubTopic(int topicID,int subTopicId,string topicName,string subTopicName)
        {
         TopicId = topicID;
         SubTopicid = subTopicID;
         TopicName = topicName;
         SubTopicName = subTopicName;
        }
 
        public int TopicId { get; set; }
        public int SubTopicId { get; set; }
        public string TopicName { get; set; }
        public string SubtopicName { get; set; } }
