    public static BaseClass Choose(ArticleType type, string name) {
        switch (type) {
            case ArticleType.Articles:
                return ClassWithChooseMethod.Choose<Articles>(name);
            case ArticleType.Questionnaire:
                return ClassWithChooseMethod.Choose<Questionnaire>(name);
            default:
                return default(BaseClass);
        }
    }
